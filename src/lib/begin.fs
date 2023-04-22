\ lib/begin.fs

\ This file is part of Sin Forth.

\ This file adds `begin` to the compiler.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

\ ==============================================================

require backward-mark.fs \ `<mark`

get-order get-current

compiler-definitions

compiler{

synonym begin <mark

}

  \ doc{
  \
  \ begin  Compilation: ( -- dest )
  \
  \ Mark the start of a sequence for repetitive execution, leaving
  \ _dest_ to be resolved by the corresponding `until`, `again` or
  \ `repeat`.
  \
  \ ``begin`` is a synonym of `<mark`.
  \
  \ See also: `while`, `do`.
  \
  \ }doc

set-current set-order
