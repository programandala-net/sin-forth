\ lib/begin.fs

\ This file is part of Sin Forth.

\ This file adds `begin` to the compiler.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012121651.
\ See change log at the end of the file.

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

\ ==============================================================
\ Change log {{{1

\ 2020-12-12: Start.
