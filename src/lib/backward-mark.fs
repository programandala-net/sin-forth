\ lib/backward-mark.fs

\ This file is part of Sin Forth.

\ This file adds `<mark` to the compiler.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012121648.
\ See change log at the end of the file.

\ ==============================================================

get-order get-current

compiler-definitions

: <mark ( -- dest )
  memory> @ ;

  \ doc{
  \
  \ <mark  Compiler: ( -- dest ) "backward-mark"
  \
  \ _dest_ is the current target memory pointer, which is hold by
  \ `memory>` to be used as the destination of a backward branch.
  \ _dest_ is typically only used by `<resolve` to compile a branch
  \ address.
  \
  \ See also: `>mark`, `begin`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-11: Start.
\
\ 2020-12-12: Finish and document.
