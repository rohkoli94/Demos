#include "ArrayHelper.h"

JNIEXPORT jdouble JNICALL Java_ArrayHelper_sumOf(JNIEnv* env, jclass, jdoubleArray values)
{
	jint n = env->GetArrayLength(values);
	jdouble* elements = env->GetDoubleArrayElements(values, NULL);
	jdouble result = 0;

	for(jint i = 0; i < n; ++i)
		result += elements[i];

	env->ReleaseDoubleArrayElements(values, elements, JNI_ABORT);

	return result;
}

JNIEXPORT void JNICALL Java_ArrayHelper_squareAll(JNIEnv* env, jclass, jdoubleArray values)
{
	jint n = env->GetArrayLength(values);
	jdouble* elements = new jdouble[n];

	env->GetDoubleArrayRegion(values, 0, n, elements);
	for(jint i = 0; i < n; ++i)
		elements[i] *= elements[i];
	env->SetDoubleArrayRegion(values, 0, n, elements);
	delete[] elements;
}
